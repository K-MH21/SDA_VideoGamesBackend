namespace FusionTech.src.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        protected readonly PersonRepository _personRepo;
        protected readonly CustomerRepository _customerRepo;
        private readonly IConfiguration _config;

        protected readonly IMapper _mapper;

        public CustomerService(
            PersonRepository personRepo,
            CustomerRepository customerRepo,
            IMapper mapper,
            IConfiguration config
        )
        {
            _customerRepo = customerRepo;
            _personRepo = personRepo;
            _mapper = mapper;
            _config = config;
        }

        public async Task<int> getAgeByEmailAsync(string email)
        {
            var person = await _personRepo.FindPersonByEmail(email);
            var customer = await _customerRepo.GetByIdAsync(person!.PersonId);
            return customer!.Age;
        }

        public async Task<CustomerReadDto> CreateOneAsync(CustomerSignUpDTO createDto)
        {
            // TODO: Check if password and other information are valid
            Entity.Customer customer = _mapper.Map<CustomerSignUpDTO, Entity.Customer>(createDto);
            PasswordUtils.HashPassword(
                createDto.PersonPassword!,
                out string hashedPassword,
                out byte[] salt
            );
            var idCounter = await _personRepo.GetIdCounterAsync(Entity.Customer.PersonType);
            customer.PersonId = PersonIdConfig.CustomerStartIndex + idCounter.CurrentId + 1;
            customer.PersonPassword = hashedPassword;
            customer.salt = salt;
            Entity.Customer categoryCreated = await _customerRepo.CreateOneAsync(customer);
            await _personRepo.UpdatePersonIdCounter(idCounter);
            return _mapper.Map<Entity.Customer, CustomerReadDto>(categoryCreated);
        }

        public async Task<string> SignInAsCustomer(string email)
        {
            Entity.Person originalPerson = (await _personRepo.FindPersonByEmail(email))!;

            var customer = await _customerRepo.GetByIdAsync(originalPerson!.PersonId);
            if (customer == null)
            {
                throw new KeyNotFoundException(
                    "You Don't have an account, you need to provide your age in the request"
                );
            }
            var tokenUtils = new TokenUtils(_config);
            return tokenUtils.generateToken(customer);
        }

        public async Task<string> SignInAsCustomer(string email, int age)
        {
            try
            {
                return await SignInAsCustomer(email);
            }
            catch (KeyNotFoundException)
            {
                var originalPerson = await _personRepo.FindPersonByEmail(email);
                var newCustomer = await _customerRepo.CreateCustomerRawSqlAsync(
                    originalPerson!.PersonId,
                    age
                );
                var tokenUtils = new TokenUtils(_config);
                return tokenUtils.generateToken(newCustomer);
            }
        }

        public async Task<bool> UpdateAgeAsync(string email, int age)
        {
            if (age < 1 || age > 120)
                throw CustomException.InternalError("Age must be between 1 and 120.");
            var person = await _personRepo.FindPersonByEmail(email);
            var customer = await _customerRepo.GetByIdAsync(person!.PersonId);
            customer!.Age = age;
            return await _customerRepo.UpdateAsync(customer);
        }

        public async Task<List<CustomerReadDto>> GetAllAsync(PaginationOptions paginationOptions)
        {
            var customers = await _customerRepo.GetAllAsync();
            if (paginationOptions.Search != null)
                customers = customers
                    .Where(c =>
                        c.PersonName.Contains(
                            paginationOptions.Search,
                            StringComparison.OrdinalIgnoreCase
                        )
                        || c.PersonEmail.Contains(
                            paginationOptions.Search,
                            StringComparison.OrdinalIgnoreCase
                        )
                        || (
                            c.PersonPhoneNumber != null
                            && c.PersonPhoneNumber.Contains(
                                paginationOptions.Search,
                                StringComparison.OrdinalIgnoreCase
                            )
                        )
                    )
                    .ToList();

            var paginatedCustomers = customers
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToList();

            return _mapper.Map<List<Entity.Customer>, List<CustomerReadDto>>(paginatedCustomers);
        }

        public async Task<int> CountCustomersAsync()
        {
            return await _customerRepo.CountAsync();
        }

        public async Task<CustomerReadDto> GetOneById(int customerId)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId);
            return _mapper.Map<Entity.Customer, CustomerReadDto>(customer!);
        }
    }
}
