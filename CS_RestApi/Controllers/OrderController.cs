using CS_RestApi.BL;
using CS_RestApi.DAL;
using CS_RestApi.DAL.Entities;
using CS_RestApi.DAL.Repositories;
using CS_RestApi.Domain;
using CS_RestApi.Exceptions;
using CS_RestApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace CS_RestApi.Controllers
{
    public class OrderController
    {
        private IOrderRepository _orderRepository;
        DbContextOptions<AzureContext> _dbOptions;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public OrderController(IOrderRepository orderRepository, DbContextOptions<AzureContext> dbOptions) 
        {
            _orderRepository = orderRepository;
            _dbOptions = dbOptions;
        }

        [HttpGet]
        [Route("orders")]
        public IEnumerable<Order> ListOrdersAsync() 
        {
            _logger.Info("Request to list orders received...");
            var orders = _orderRepository.GetOrders();
            _logger.Trace($"Found {orders.Count()} orders");
            return orders;
        }

        [HttpPatch]
        [Route("orders/setPaid")]
        public async Task<AppResponse> SetOrderStatusAsync([FromBody]PaymentInfoRequest request) 
        {
            _logger.Info("Request to set order status received...");
            _logger.Info($"Order number: {request.OrderNumber}");
            _logger.Info($"Order paid: {request.Paid}");

            try
            {
                _logger.Info("request enqueued...");
                PaymentQueueManager.EnqueuePaymentInfoRequest(request);
                return new AppResponse("request enqueued");
            }
            catch (OrderNotFoundException e) 
            {
                _logger.Fatal(e);
                return new AppResponse(e.Message, false);
            }
        }

        [HttpPost]
        [Route("orders/create")]
        public async Task<AppResponse> CreateOrderAsync([FromBody]CreateOrderRequest request) 
        {
            _logger.Info("Request to create order received");
            _logger.Info($"Customer name {request.CustomerName}");
            _logger.Info($"Item Count {request.OrderItems.Count}");
            
            try
            {
                var order = MapHelper.MapCreateOrderRequestToOrder(request);
                var orderNumber = await _orderRepository.CreateNewOrderAsync(order);
                _logger.Info("New order created succesfully");

                return new AppResponse($"order {orderNumber} created");
            }
            catch (Exception e)
            {
                _logger.Fatal(e);
                return new AppResponse(e.Message, false);
            }
        }

        /// <summary>
        /// My humble attempt to process orders in queue asynchronously
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("orders/processPayments")]
        public AppResponse ProcessPayments()
        {
            _logger.Info("Request to process orders aync received");

            try
            {
                _logger.Info($"{PaymentQueueManager.RequestCount} requests waiting to be processed");
                PaymentQueueManager.InitContext(_dbOptions);
                PaymentQueueManager.Proccess();
                return new AppResponse("All Requests dequeued adn processed");
            }
            catch (Exception e) 
            {
                _logger.Fatal(e);
                return new AppResponse(e.Message, false);
            }
        }
    }

}
