namespace FusionTech.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        protected readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Create a new order
        [Authorize(Policy = "Customer")]
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOneAsync(
            [FromBody] OrderCreateDto orderCreateDto
        )
        {
            var authenticateClaims = HttpContext.User;
            var userIdClaim = authenticateClaims.FindFirst(c =>
                c.Type == ClaimTypes.NameIdentifier
            );

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return BadRequest("User ID not found in claims or is not a valid integer.");
            }

            return await _orderService.CreateOneAsync(userId, orderCreateDto);
        }

        // Get all orders for a customer
        [Authorize(Policy = "Customer")]
        [HttpGet]
        public async Task<ActionResult<List<OrderReadDto>>> GetCustomerAllOrders()
        {
            var authenticateClaims = HttpContext.User;
            var userIdClaim = authenticateClaims.FindFirst(c =>
                c.Type == ClaimTypes.NameIdentifier
            );

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return BadRequest("User ID not found in claims or is not a valid integer.");
            }
            var orders = await _orderService.GetOrderByIdAsync(userId);
            if (orders == null || orders.Count == 0)
            {
                throw CustomException.Forbidden(
                    "Forbidden. You do not have access rights to view this content."
                );
            }

            return Ok(orders);
        }

        // Get all orders
        [Authorize(Policy = "admin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<OrderListDto>>> GetAllOrders()
        {
            var authenticateClaims = HttpContext.User;
            var userIdClaim = authenticateClaims.FindFirst(c =>
                c.Type == ClaimTypes.NameIdentifier
            );

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return BadRequest("User ID not found in claims or is not a valid integer.");
            }
            var orders = await _orderService.GetAllAsync();
            if (orders == null || orders.Count == 0)
            {
                throw CustomException.Forbidden("No Orders has been placed in the system");
            }

            var orderCount = await _orderService.CountOrdersAsync();
            var orderListDto = new OrderListDto { Orders = orders, TotalCount = orderCount };

            return Ok(orderListDto);
        }
    }
}
