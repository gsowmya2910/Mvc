// ----------------------------------------------------------------------
// <copyright file="IUpdateInterp.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using Interfaces;

    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IRegion" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IMainFrameUsercode" />
    /// <seealso cref="ConfigInterp.Bl.Update.IKeyInfoIn" />
    /// <seealso cref="ConfigInterp.Bl.Update.IRecords" />
    public interface IUpdateInterp : IRegion, IMainFrameUsercode, IKeyInfoIn, IRecords
    {
    }
}