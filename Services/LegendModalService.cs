using Microsoft.AspNetCore.Components;

namespace OptechXPortalAdmin.Services
{
	public class LegendModalService : ILegendModalService
	{
        private bool showModal = false;

        public void ShowModal() { }

        public void CloseModal()
        {
            showModal = false;
        }

        public bool IsModalVisible()
        {
            return showModal;
        }

        public EventCallback<bool> OnClose => EventCallback.Factory.Create<bool>(this, CloseModal);
    }
}

