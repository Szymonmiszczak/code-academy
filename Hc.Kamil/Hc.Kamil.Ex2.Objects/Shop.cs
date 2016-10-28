﻿using System;
using Hc.Kamil.Ex2.Objects.Models;
using Hc.Kamil.Ex2.Objects.UserInterface;

namespace Hc.Kamil.Ex2.Objects
{
    public class Shop : IShop
    {
        private readonly ISalesman _salesman;

        private readonly IWarehouse _warehouse;

        public Shop(ISalesman salesman, IWarehouse warehouse)
        {
            _salesman = salesman;
            _warehouse = warehouse;
        }

        public void HandleCustomer()
        {
            _salesman.WelcomeCustomer();

            while (true)
            {
                try
                {
                    switch (_salesman.AskAboutAction())
                    {
                        case SalesmanAction.AddProduct:
                            _warehouse.AddProduct(_salesman.ReadProductInformation(true, true));
                            break;
                        case SalesmanAction.CheckState:
                            _salesman.ShowAvailableProducts(_warehouse.GetAvailableProducts());
                            break;
                        case SalesmanAction.SellProduct:
                            _warehouse.TryGetProduct(_salesman.ReadProductInformation(false, true));
                            break;
                    }

                    if (_salesman.Finish())
                        return;
                }
                catch (Exception exception)
                {
                    _salesman.ShowError(exception.Message);
                }
            }
        }
    }
}