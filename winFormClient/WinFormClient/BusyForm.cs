﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormClient
{
    public partial class BusyForm : Form
    {
        public Action worker { get; set; }
        public BusyForm(Action wrk)
        {
            InitializeComponent();
            
            if (wrk == null)
                throw new ArgumentNullException();
            worker = wrk;
        }
        
       
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Task.Factory.StartNew(worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
           Task.Factory.StartNew(worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        
    }
}
