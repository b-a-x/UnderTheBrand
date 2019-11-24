﻿using System.ComponentModel;
using UnderTheBrand.Domain.Entity;
using UnderTheBrand.Infrastructure.Mobile.ViewModels;
using Xamarin.Forms;

namespace UnderTheBrand.Infrastructure.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel _viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this._viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            _viewModel = new ItemDetailViewModel(item);
            BindingContext = _viewModel;
        }
    }
}