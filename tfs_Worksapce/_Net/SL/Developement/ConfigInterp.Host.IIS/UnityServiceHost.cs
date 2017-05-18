﻿// ----------------------------------------------------------------------
// <copyright file="UnityServiceHost.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Host.IIS
{
    using System;
    using System.ServiceModel;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="System.ServiceModel.ServiceHost" />
    public class UnityServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceHost"/> class.
        /// </summary>
        public UnityServiceHost()
        {
            this.Container = Global.Container;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">The type of hosted service.</param>
        /// <param name="baseAddresses">An array of type <see cref="T:System.Uri" /> that contains the base addresses for the hosted service.</param>
        public UnityServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.Container = Global.Container;
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            if (this.Description.Behaviors.Find<UnityServiceBehavior>() == null)
            {
                this.Description.Behaviors.Add(new UnityServiceBehavior(this.Container));
            }

            base.OnOpening();
        }
    }
}