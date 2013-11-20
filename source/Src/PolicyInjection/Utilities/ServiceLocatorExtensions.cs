// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.Practices.ServiceLocation;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Utility
{
    /// <summary>
    /// Provides extension methods on <see cref="IServiceLocator"/> for convenience.
    /// </summary>
    public static class ServiceLocatorExtensions
    {
        /// <summary>
        /// Disposes <paramref name="locator"/> if it implements the <see cref="IDisposable"/> interface.
        /// </summary>
        /// <param name="locator">The service locator to dispose, if possible.</param>
        public static void Dispose(this IServiceLocator locator)
        {
            if (locator == null) return;

            var disposable = locator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
