using Blazored.Modal;
using Blazored.Modal.Services;
using ClkTeknoloji.CustomerDashboard.CustomComponents.ModalComponents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.Utilis
{
    public class ModalManager
    {
        private readonly IModalService modelService;
        public ModalManager(IModalService ModelService)
        {
            this.modelService = ModelService;
        }
        public async Task ShowMessageAsync(string Title, string Message, int Duration = 0)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = modelService.Show<ShowMessagePopupComponent>(Title, mParams);

            if (Duration > 0)
            {
                await Task.Delay(Duration);
                modalRef.Close();
            }
        }

        public async Task<bool> ConfirmationAsync(string Title, string Message)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = modelService.Show<ConfirmationPopupComponent>(Title, mParams);
            var modelResult = await modalRef.Result;
            return !modelResult.Cancelled;
        }
    }
}
