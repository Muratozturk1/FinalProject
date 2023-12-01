using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public static class Messages
{
    public static string ProductAdded = "Ürün Eklendi.";
    public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
    public static string MaintenanceTime = "Sistem bakımda";
    public static string ProductsListed = "Ürünler listelendi";
    public static string ProductCountOfCategeroyError = "Bir kategoride en fazla 10 ürün olabilir";
    public static string ProductNameAlreadyExists = "Bu isimde bir ürün var zaten intihar edicem";
    public static string CategoryLimitExceded = "Kategori limiti aşıladığı için yeni ürün eklenemiyor";
    public static string AuthorizationDenied = "Yetkiniz yok.";
    internal static string UserRegistered;
    internal static string UserNotFound;
    internal static string PasswordError;
    internal static string SuccessfulLogin;
    internal static string UserAlreadyExists;
    internal static string AccessTokenCreated;
}
