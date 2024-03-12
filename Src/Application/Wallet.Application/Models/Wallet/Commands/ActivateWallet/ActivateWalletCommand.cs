﻿using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.ActivateWallet
{
    public class ActivateWalletCommand:ICommand
    {
        public int WalletId { get; set; }
    }
}
