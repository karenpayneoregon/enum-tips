#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineWebApplication.Interfaces;
using WineWebApplication.Models;

namespace WineWebApplication.Pages;

public class IndexModel(IWineService wineService) : PageModel
{
    public List<WineGroup> WineGroups { get; private set; }

    public void OnGet()
    {
        WineGroups = wineService.GetWineGroups();
    }
}

