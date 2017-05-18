// ----------------------------------------------------------------------
// <copyright file="BootStrapper.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Unity
{
    using Bl;
    using Bl.BenefitMatrix;
    using Bl.Description;
    using Bl.Inquire;
    using Bl.Interfaces;
    using Bl.Update;
    using Contracts;
    using Microsoft.Practices.Unity;
    using ServiceLibrary;
    using Sql;

    /// <summary>
    /// The class
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Configures the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IConfigInterpService, ConfigInterpService>()
                .RegisterType<ConfigInterpService>()
                .RegisterType<IBenefitMatrixHandler, BenefitMatrixHandler>()
                .RegisterType<ICipInquireHandler, CipInquireHandler>()
                .RegisterType<ICipUpdateHandler, CipUpdateHandler>()
                .RegisterType<IConfigInterpSqlHandler, ConfigInterpSqlHandler>()
                .RegisterType<IDescriptionMasterHandler, DescriptionMasterHandler>()
                .RegisterType<IValidation, Validation>()
                .RegisterType<IConverter, Converter>()
                .RegisterType<IStepConverter, StepConverter>()
                .RegisterType<ISqlServerDataAccess, DirectSqlServerDataAccess>()
               //// .RegisterType<ISqlServerDataAccess, EntityFrameworkDataAccess>()
                .RegisterType<IWorkflowManager, WorkflowManager>();
        }
    }
}