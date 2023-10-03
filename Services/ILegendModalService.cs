using Microsoft.AspNetCore.Components;

namespace OptechXPortalAdmin.Services
{
    public interface ILegendModalService
    {
        void ShowModal();

        void CloseModal();

        bool IsModalVisible();

        EventCallback<bool> OnClose { get; }
    }
}

