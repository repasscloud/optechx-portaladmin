using OptechXPortalAdmin.Shared.Models.Support;

namespace OptechXPortalAdmin.Services
{
    public class SupportTicketService : ISupportTicketService
	{
        private readonly HttpClient _httpClient;

        public SupportTicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // list of support tickets
        public List<SupportTicket> SupportTickets { get; set; } = new List<SupportTicket>();

        public Task CloseSupportTicketAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<int> FindSupportTicketAsync(int ticketId, string accountId)
        {
            // if 0 is returned, then valid object found, will navigate to next page
            throw new NotImplementedException();
        }

        // get all support tickets
        public async Task LoadAllSupportTickets()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SupportTicket>>($"/SupportTicket/admin/all");
            if (response != null)
            {
                SupportTickets = response;
            }
        }

        // get all assigned support tickets
        public async Task LoadAssignedSupportTickets()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SupportTicket>>("/SupportTicket/admin/all/assigned");
            if (response != null)
            {
                SupportTickets = response;
            }
        }

        // get all closed support tickets
        public async Task LoadClosedSupportTickets()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SupportTicket>>("/SupportTicket/admin/all/closed");
            if (response != null)
            {
                SupportTickets = response;
            }
        }

        // get all open support tickets
        public async Task LoadOpenSupportTickets()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SupportTicket>>("/SupportTicket/admin/all/open");
            if (response != null)
            {
                SupportTickets = response;
            }
        }

        // get all pending support tickets
        public async Task LoadPendingSupportTickets()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SupportTicket>>("/SupportTicket/admin/all/pending");
            if (response != null)
            {
                SupportTickets = response;
            }
        }
    }
}

