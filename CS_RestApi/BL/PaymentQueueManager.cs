using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;
using CS_RestApi.DAL;
using CS_RestApi.DAL.Repositories;
using CS_RestApi.Domain;
using CS_RestApi.Exceptions;
using CS_RestApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace CS_RestApi.BL
{
    public static class PaymentQueueManager
    {
        private static ConcurrentQueue<PaymentInfoRequest> _queue;
        private static AzureContext _context;

        public static int RequestCount => _queue.Count;

        static PaymentQueueManager()
        {
            _queue = new ConcurrentQueue<PaymentInfoRequest>();
            _context = null;
        }

        public static void InitContext(DbContextOptions<AzureContext> options) 
        {
            if (_context is null) 
            {
                _context = new AzureContext(options);
            }
        }

        public static void EnqueuePaymentInfoRequest(PaymentInfoRequest request)
        {
            _queue.Enqueue(request);
        }

        public static void Proccess()
        {
            while (_queue.TryDequeue(out PaymentInfoRequest? request))
            {
                if (request is not null) 
                {
                    var order = _context.Orders.FirstOrDefault(x => x.OrderNumber == request.OrderNumber);

                    if (order is not null)
                    {
                        order.OrderStatus = request.Paid ? OrderStatusEnum.PaidOff : OrderStatusEnum.Canceled;
                        _context.SaveChanges();
                    }
                }
            }

            _context.Dispose();
        }
    }
}
