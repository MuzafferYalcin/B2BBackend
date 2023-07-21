using Application.Abstractions;
using Application.Repositories;
using Application.Utilities.Security.JWT;
using Autofac;
using Persistence.Repositories;
using Persistence.Services;

namespace Application.Dependency.Autofac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<BasketService>().As<IBasketService>();
            builder.RegisterType<OperationClaimService>().As<IOperationClaimService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerDiscountService>().As<ICustomerDiscountService>();
            builder.RegisterType<OrderItemManager>().As<IOrderItemService>();

           
            builder.RegisterType<EfBasketDal>().As<IBasketDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfCustomerDiscountDal>().As<ICustomerDiscountDal>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();
            builder.RegisterType<EfOrderItemDal>().As<IOrderItemDal>();

            builder.RegisterType<TokenHelper>().As<ITokenHelper>();


        }
    }
}
