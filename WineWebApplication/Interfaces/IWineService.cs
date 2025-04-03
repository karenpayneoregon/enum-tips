using WineWebApplication.Models;

namespace WineWebApplication.Interfaces;

/// <summary>
/// Defines the contract for wine-related operations and services.
/// </summary>
/// <remarks>
/// This interface provides methods for retrieving and managing wine data, 
/// including grouping wines by their types.
/// </remarks>
public interface IWineService
{
    List<WineGroup> GetWineGroups();
}

