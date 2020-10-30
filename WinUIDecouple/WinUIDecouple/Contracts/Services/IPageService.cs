using System;

namespace WinUIDecouple.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
