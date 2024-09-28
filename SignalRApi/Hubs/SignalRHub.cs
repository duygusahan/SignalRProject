using Microsoft.AspNetCore.SignalR;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DataAccessLayer.Context;

namespace SignalRApi.Hubs
{
    public class SignalRHub:Hub
    {
       private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationsService _notificationsService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationsService notificationsService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationsService = notificationsService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount" , value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveCountByCategoryNameHamburger" , value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveCountByCategoryNameDrink", value6);

            var value7 = _productService.TProductPriceAvg();    
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00") + "₺");

            var value8 = _productService.TProductPriceByMax();
            await Clients.All.SendAsync("ReceiveProductPriceByMax", value8);

            var value9 = _productService.TProductPriceByMin();
            await Clients.All.SendAsync("ReceiveProductPriceByMin", value9);

            var value10 = _productService.THamburgerPriceAvg();
            await Clients.All.SendAsync("ReceiveHamburgerPriceAvg", value10.ToString("0.00") + "₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13 + "₺");

            var value14 = _moneyCaseService.TTotalMoneyCase();
            await Clients.All.SendAsync("ReceiveTotalMoneyCase", value14.ToString("0.00") + "₺");

            var value15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value15.ToString("0.00") + "₺");

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);

        }

        public async Task SendProgress()
        {
            var value=_moneyCaseService.TTotalMoneyCase();
            await Clients.All.SendAsync("ReceiveTotalMoneyCase" ,value.ToString("0.00" )+ "₺");

            var value2=_orderService.TActiveOrderCount() ;
            await Clients.All.SendAsync("ReceiveActiveOrderCount" , value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3);
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList" ,  values);
        }

        public async Task SendNotification()
        {
            var values=_notificationsService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", values);

            var natificationListByFalse=_notificationsService.TGetAllNotificationsByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", natificationListByFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }


    }
}
