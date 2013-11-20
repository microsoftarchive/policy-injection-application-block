// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;

[assembly: ReliabilityContract(Consistency.WillNotCorruptState, Cer.None)]

[assembly: AssemblyTitle("Enterprise Library Policy Injection Application Block")]
[assembly: AssemblyDescription("Enterprise Library Policy Injection Application Block")]
[assembly: AssemblyVersion("6.0.0.0")]
[assembly: AssemblyFileVersion("6.0.1311.0")]
[assembly: AssemblyInformationalVersion("6.0.1311-prerelease")]

[assembly: AllowPartiallyTrustedCallers]

[assembly: ComVisible(false)]

[assembly: HandlesSection(PolicyInjectionSettings.SectionName)]

[assembly: AddApplicationBlockCommand(
                PolicyInjectionSettings.SectionName,
                typeof(PolicyInjectionSettings),
                TitleResourceName = "AddPolicyInjectionSettings",
                TitleResourceType = typeof(DesignResources))]
