using OptechXPortalAdmin.Shared.Models.Support;

namespace OptechXPortalAdmin.Services
{
	public interface ISupportTicketService
	{
		List<SupportTicket> SupportTickets { get; }

		Task LoadAllSupportTickets();
		Task LoadOpenSupportTickets();
		Task LoadAssignedSupportTickets();
		Task LoadPendingSupportTickets();
		Task LoadClosedSupportTickets();

		// old functions
		Task CloseSupportTicketAsync(int ticketId);
		Task<int> FindSupportTicketAsync(int ticketId, string accountId);
        
    }
}

