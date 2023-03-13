using A2F.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoMo;
using Newtonsoft.Json.Linq;
using Novatic.Models;
using Novatic.Models.CRM;
using Novatic.Models.CRM.RequestForm;
using Novatic.Repository;
using Novatic.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Novatic.Controllers.CRM
{
    [Route("[controller]")]
    [ApiController]

    public class MomoPaymentController : BaseController
    {
        IOrdersRepository orderRepository;
        IShopRepository shopRepository;
        IOrderTransactionRepository ordersTransactionRepository;
        ITransactionsRepository repository;
        INotificationRepository notificationRepository;

        public MomoPaymentController(
                IOrdersRepository _orderRepository,
                IShopRepository _shopRepository,
                IOrderTransactionRepository _ordersTransactionRepository,
                INotificationRepository _notificationRepository,
                ITransactionsRepository _transactionsRepository,
                ICacheHelper cacheHelper) : base(cacheHelper)
        {
            orderRepository = _orderRepository;
            shopRepository = _shopRepository;
            ordersTransactionRepository = _ordersTransactionRepository;
            repository = _transactionsRepository;
            notificationRepository = _notificationRepository;
        }


        [HttpPost]
        [Route("api/PaymentWithMOMO")]
        //   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PaymentWithMOMO([FromBody] PaymentRequestForm request)
        {
            //string UserIDSession = this.GetLoggedInUserId().ToString();
            //string AccountTypeId = this.GetLoggedInAccountTypeId().ToString();
            //if (AccountTypeId.Equals("10001"))
            //{
            //    var novaticResponse1 = NovaticResponse.BadRequestMessage("account không có quyền vào trang này này");
            //    return Ok(novaticResponse1);
            //}
            //if (UserIDSession == null)
            //{
            //    var novaticResponse1 = NovaticResponse.BadRequestMessage("đăng nhập để thực hiện chức năng này");
            //    return Ok(novaticResponse1);

            //}

            //2. add new object
            try
            {
                //request params need to request to MoMo system
                string endpoint = SystemConstant.API_ENDPOINT;
                string partnerCode = SystemConstant.PARTNER_CODE;
                string accessKey = SystemConstant.ACCESS_KEY;
                string serectkey = SystemConstant.SECRET_KEY;
                string orderInfo = request.OrderInfor;
                string redirectUrl = SystemConstant.RETURN_URL;
                string ipnUrl = SystemConstant.NOTIFI_URL;
                string requestType = "captureWallet";

                string amount = request.Amount.ToString();
                string orderId = Guid.NewGuid().ToString() + "_" + request.OrderId;
                string requestId = Guid.NewGuid().ToString() + "_" + request.CartID;
                string extraData = "";

                //Before sign HMAC SHA256 signature
                string rawHash = "accessKey=" + accessKey +
                    "&amount=" + amount +
                    "&extraData=" + extraData +
                    "&ipnUrl=" + ipnUrl +
                    "&orderId=" + orderId +
                    "&orderInfo=" + orderInfo +
                    "&partnerCode=" + partnerCode +
                    "&redirectUrl=" + redirectUrl +
                    "&requestId=" + requestId +
                    "&requestType=" + requestType
                    ;


                MoMoSecurity crypto = new MoMoSecurity();
                //sign signature SHA256
                string signature = crypto.signSHA256(rawHash, serectkey);

                //build body json request
                JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", "en" },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }

            };
                string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

                JObject jmessage = JObject.Parse(responseFromMomo);

                var novaticResponse = NovaticResponse.SUCCESS(jmessage.GetValue("payUrl").ToString());

                return Ok(novaticResponse);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message + " - " + e.InnerException);
            }
            return BadRequest();
        }



        [HttpGet]
        [Route("api/ReturnURL")]
        //   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ReturnURL()
        {

            //string UserIDSession = this.GetLoggedInUserId().ToString();
            //string AccountTypeId = this.GetLoggedInAccountTypeId().ToString();
            //if (AccountTypeId.Equals("10001"))
            //{
            //    var novaticResponse1 = NovaticResponse.BadRequestMessage("account không có quyền vào trang này này");
            //    return Ok(novaticResponse1);
            //}
            //if (UserIDSession == null)
            //{
            //    var novaticResponse1 = NovaticResponse.BadRequestMessage("đăng nhập để thực hiện chức năng này");
            //    return Ok(novaticResponse1);

            //}

            //2. add new object
            try
            {
                string mess = Request.QueryString.ToString().Remove(Request.QueryString.ToString().IndexOf("payType=") - 1);
                if (mess.Remove(0, mess.IndexOf("message") - 1) != "&message=Successful.")
                {
                    var novaticResponse = NovaticResponse.BadRequestMessage("transaction failed");

                    return Ok(novaticResponse);
                }

                else
                {
                    var novaticResponse = NovaticResponse.SUCCESS("transaction Successfull");

                    return Ok(novaticResponse);
                }


            }
            catch (Exception e)
            {

                return BadRequest(e.Message + " - " + e.InnerException);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/NotifiURL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> NotifiURL([FromBody] paramMomoPayment request)
        {
            string UserIDSession = this.GetLoggedInUserId().ToString();
            string AccountTypeId = this.GetLoggedInAccountTypeId().ToString();
            int amount = Convert.ToInt32(request.amount);
            if (AccountTypeId.Equals("10001"))
            {
                var novaticResponse1 = NovaticResponse.BadRequestMessage("account không có quyền vào trang này này");
                return Ok(novaticResponse1);
            }
            if (UserIDSession == null)
            {
                var novaticResponse1 = NovaticResponse.BadRequestMessage("đăng nhập để thực hiện chức năng này");
                return Ok(novaticResponse1);

            }
            int AccountID = Convert.ToInt32(UserIDSession);
            //2. add new object
            try
            {
                List<Transactions> Transactions = new List<Transactions>();

                string OrderID = request.orderId;
                string listOrderID = OrderID.Substring(OrderID.IndexOf("_") + 1);
                string[] orderID = listOrderID.Split('_');
                List<int> listOrder = new List<int>();
                foreach (var item in orderID)
                {
                    int a = Convert.ToInt32(item);
                    listOrder.Add(a);
                }

                // logic add notification
                Notification notification = new Notification();
                notification.Active = 1;
                notification.CreatedTime = DateTime.Now;
                notification.AccountId = AccountID;

                //auto correct transaction
                Transactions transactions = new Transactions();
                transactions.Active = 1;
                transactions.Name = "momo";
                transactions.TransactionStatusId = 1000001;
                transactions.TransactionTypeId = 1000003;
                transactions.Description = "";
                transactions.Info = "";
                transactions.ReceiverInfo = request.orderInfo;
                transactions.CreatedTime = DateTime.Now;
                transactions.Amount = amount;
                transactions.SenderInfo = request.partnerCode;
                var newObj = await repository.Add(transactions);
                foreach (int model in listOrder)
                {      //data validation


                    if (request.message != "Successful.")
                    {
                        Orders orders = orderRepository.GetORdersByOrderId(model);

                        notification.Description = "transaction failed";
                        notification.SenderId = orders.ShopId;
                        notification.Name = orders.Name;
                        notification.NotificationStatusId = 1000002;
                        await notificationRepository.Add(notification);

                        var novaticResponse = NovaticResponse.BadRequestMessage("transaction momo failed");
                        return Ok(novaticResponse);
                    }

                    else
                    {

                        //logig notification
                        Orders orders = orderRepository.GetORdersByOrderId(model);
                        orders.OrderPaymentStatusId = 1000001;
                        notification.Description = "transaction momo success";
                        notification.SenderId = orders.ShopId;
                        notification.Name = orders.Name;
                        notification.NotificationStatusId = 1000002;
                        //2. add new object
                        try
                        {

                            await orderRepository.Update(orders);
                            await notificationRepository.Add(notification);

                            if (newObj.Id > 0)
                            {
                                OrderTransaction transaction = new OrderTransaction();
                                transaction.TransactionId = newObj.Id;
                                transaction.OrderId = model;
                                transaction.Name = "momo";
                                transaction.Description = "momo";
                                transaction.Active = 1;
                                transaction.CreatedTime = DateTime.Now;
                                await ordersTransactionRepository.Add(transaction);

                            }
                            else
                            {
                                return NotFound();
                            }
                        }
                        catch (Exception e)
                        {

                            return BadRequest(e.Message + " - " + e.InnerException);
                        }

                    }
                }
                var novaticResponse1 = NovaticResponse.SUCCESS("transaction Successfull");

                return Ok(novaticResponse1);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message + " - " + e.InnerException);
            }
            return BadRequest();
        }

    }
}

