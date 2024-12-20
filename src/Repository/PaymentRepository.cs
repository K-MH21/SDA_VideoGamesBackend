namespace FusionTech.src.Repository
{
    public class PaymentRepository
    {
        protected DbSet<Payment> _payment;
        protected DatabaseContext _databaseContext;

        public PaymentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _payment = databaseContext.Set<Payment>();
        }

        public async Task<Payment> CreateOneAsync(Payment newPayment)
        {
            await _payment.AddAsync(newPayment);
            await _databaseContext.SaveChangesAsync();
            return newPayment;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _payment.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(Guid id)
        {
            return await _payment.FindAsync(id);
        }

        public async Task<bool> DeleteOneAsync(Payment payment)
        {
            _payment.Remove(payment);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOneAsync(Payment updatePayment)
        {
            _payment.Update(updatePayment);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
