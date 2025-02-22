
namespace OrderService.Server
{
    class OrderService : IOrderService
    {
        private readonly List<Order> _order = new();

        public async Task<CreateOrderResponse> Create(CreateOrderRequest createOrder)
        {
            Order order = new Order()
            {
                Id = createOrder.Id,
                UserId = createOrder.Id,
                CreateAt = createOrder.TimeCreate,
                Status = createOrder.Status
            };
            _order.Add(order);
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
            int removeOrder = _order.RemoveAll(c => c.Id == Id);
            if(removeOrder == 0)
                throw new Exception("Заказ не найден!");
            return true;
        }

        public async Task<List<CreateOrderResponse>> GetAll()
        {
            var allOrder = _order.ToList();
            var orderResponse = allOrder.Select(o => new CreateOrderResponse{Id = o.Id, Status = o.Status, TimeCreate = o.CreateAt}).ToList();
            return orderResponse;
        }

        public async Task<CreateOrderResponse> GetById(Guid Id)
        {
            var allOrder = _order.ToList();
            var orderResponce = allOrder.Where(o => o.Id == Id);
            return (CreateOrderResponse)orderResponce;
        }

        public async Task<CreateOrderResponse> Update(Guid Id, CreateOrderRequest createOrder)
        {
            var updateOrder = _order.Where(o => o.Id == Id);
            return (CreateOrderResponse)updateOrder.Select(o => new CreateOrderResponse { Id = o.Id, Status = o.Status, TimeCreate = o.CreateAt });
        }
    }
}