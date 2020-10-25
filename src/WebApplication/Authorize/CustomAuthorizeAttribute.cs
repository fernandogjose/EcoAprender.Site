using System.Web.Mvc;

namespace WebApplication.Authorize
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //--- Quando é Anonymous
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                return;

            //--- Validação na session
            if (filterContext.HttpContext.Session == null || filterContext.HttpContext.Session["UsuarioId"] == null)
            {
                filterContext.Result = new RedirectResult("/Portal-Do-Aluno");
                return;
            }

            //--- Validar se o usuário esta logado
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Portal-Do-Aluno");
                return;
            }

            if (!(filterContext.Result is HttpUnauthorizedResult)) return;

            filterContext.Result = new RedirectResult("/Portal-Do-Aluno");
        }
    }
}