

namespace OrderService.Server
{
    class OrderService : IOrderService
    {
        private readonly MarketProjectDbContext _context;

        public OrderService(MarketProjectDbContext context)
        {
            _context = context;
        }

        public async Task<CreateOrderResponse> Create(CreateOrderRequest createOrder)
        {
            Order order = new Order()
            {
                Id = createOrder.Id,
                UserId = createOrder.Id,
                CreateAt = createOrder.TimeCreate,
                Status = createOrder.Status
            };
            await _context.Order.AddAsync(order);
            CreateOrderResponse createOrderResponse = new CreateOrderResponse()
            {
                Id = createOrder.Id,
                Status = createOrder.Status,
                TimeCreate = createOrder.TimeCreate
            };
            return createOrderResponse;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var removeOrder = await _context.Order.FindAsync(Id);
            if(removeOrder != null)
            {
                _context.Order.Remove(removeOrder);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Заказ не найден!");
            }

        }

        public async Task<List<CreateOrderResponse>> GetAll()
        {
            var orderResponse = await _context.Order.Select(o => new CreateOrderResponse{Id = o.Id, Status = o.Status, TimeCreate = o.CreateAt}).ToListAsync();
            return orderResponse;
        }

        public async Task<List<CreateOrderResponse>> GetByDateTime(DateTime dateTime)
        {
            var order = await _context.Order.Where(o => o.CreateAt == dateTime).ToListAsync();
            if (order == null)
            {
                throw new Exception("Заказ не найден!");
            }

            var orderResponse = order.Select(o => new CreateOrderResponse{Id = o.Id, Status = o.Status, TimeCreate = o.CreateAt}).ToList();
            return orderResponse;
        }

        public async Task<CreateOrderResponse> GetById(Guid Id)
        {
            var order = await _context.Order.FirstOrDefaultAsync(o => o.Id == Id);
            if (order == null)
            {
                throw new Exception("Заказ не найден!");
            }
            var orderResponse = new CreateOrderResponse
            {
                Id = order.Id,
                Status = order.Status,
                TimeCreate = order.CreateAt
            };
            return orderResponse;
        }

        public async Task<List<CreateOrderResponse>> GetByStatus(Status status)
        {
            var order = await _context.Order.Where(o => o.Status == status).ToListAsync();
            var orderResponse = order.Select(o => new CreateOrderResponse{Id = o.Id, Status = o.Status, TimeCreate = o.CreateAt}).ToList();
            return orderResponse;
        }

        public async Task<CreateOrderResponse> Update(Guid Id, CreateOrderRequest createOrder)
        {
            var updateOrder = await _context.Order.Where(o => o.Id == Id).ToListAsync();
            var order = updateOrder.FirstOrDefault();
            if (order == null)
            {
                throw new Exception("Заказ не найден!");
            }
            return new CreateOrderResponse { Id = order.Id, Status = order.Status, TimeCreate = order.CreateAt };
        }
    }
}