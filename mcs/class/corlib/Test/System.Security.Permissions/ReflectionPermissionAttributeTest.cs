//
// ReflectionPermissionAttributeTest.cs - NUnit Test Cases for ReflectionPermissionAttribute
//
// Author:
//	Sebastien Pouliot (spouliot@motus.com)
//
// (C) 2003 Motus Technologies Inc. (http://www.motus.com)
//

using NUnit.Framework;
using System;
using System.Security;
using System.Security.Permissions;

namespace MonoTests.System.Security.Permissions {

	[TestFixture]
	public class ReflectionPermissionAttributeTest : Assertion {

		[Test]
		public void Default () 
		{
			ReflectionPermissionAttribute a = new ReflectionPermissionAttribute (SecurityAction.Assert);
			AssertEquals ("Flags", ReflectionPermissionFlag.NoFlags, a.Flags);
			Assert ("MemberAccess", !a.MemberAccess);
			Assert ("ReflectionEmit", !a.ReflectionEmit);
			Assert ("TypeInformation", !a.TypeInformation);
			AssertEquals ("TypeId", a.ToString (), a.TypeId.ToString ());
			Assert ("Unrestricted", !a.Unrestricted);

			ReflectionPermission perm = (ReflectionPermission) a.CreatePermission ();
			AssertEquals ("CreatePermission.Flags", ReflectionPermissionFlag.NoFlags, perm.Flags);
		}

		[Test]
		public void Action () 
		{
			ReflectionPermissionAttribute a = new ReflectionPermissionAttribute (SecurityAction.Assert);
			AssertEquals ("Action=Assert", SecurityAction.Assert, a.Action);
			a.Action = SecurityAction.Demand;
			AssertEquals ("Action=Demand", SecurityAction.Demand, a.Action);
			a.Action = SecurityAction.Deny;
			AssertEquals ("Action=Deny", SecurityAction.Deny, a.Action);
			a.Action = SecurityAction.InheritanceDemand;
			AssertEquals ("Action=InheritanceDemand", SecurityAction.InheritanceDemand, a.Action);
			a.Action = SecurityAction.LinkDemand;
			AssertEquals ("Action=LinkDemand", SecurityAction.LinkDemand, a.Action);
			a.Action = SecurityAction.PermitOnly;
			AssertEquals ("Action=PermitOnly", SecurityAction.PermitOnly, a.Action);
			a.Action = SecurityAction.RequestMinimum;
			AssertEquals ("Action=RequestMinimum", SecurityAction.RequestMinimum, a.Action);
			a.Action = SecurityAction.RequestOptional;
			AssertEquals ("Action=RequestOptional", SecurityAction.RequestOptional, a.Action);
			a.Action = SecurityAction.RequestRefuse;
			AssertEquals ("Action=RequestRefuse", SecurityAction.RequestRefuse, a.Action);
		}

		[Test]
		public void Flags () 
		{
			ReflectionPermissionAttribute attr = new ReflectionPermissionAttribute (SecurityAction.Assert);
			attr.Flags = ReflectionPermissionFlag.MemberAccess;
			Assert ("Flags/MemberAccess=MemberAccess", attr.MemberAccess);
			Assert ("Flags/MemberAccess=ReflectionEmit", !attr.ReflectionEmit);
			Assert ("Flags/MemberAccess=TypeInformation", !attr.TypeInformation);
			attr.Flags |= ReflectionPermissionFlag.ReflectionEmit;
			Assert ("Flags/ReflectionEmit=MemberAccess", attr.MemberAccess);
			Assert ("Flags/ReflectionEmit=ReflectionEmit", attr.ReflectionEmit);
			Assert ("Flags/ReflectionEmit=TypeInformation", !attr.TypeInformation);
			attr.Flags |= ReflectionPermissionFlag.TypeInformation;
			Assert ("Flags/TypeInformation=MemberAccess", attr.MemberAccess);
			Assert ("Flags/TypeInformation=ReflectionEmit", attr.ReflectionEmit);
			Assert ("Flags/TypeInformation=TypeInformation", attr.TypeInformation);
			attr.Flags = ReflectionPermissionFlag.NoFlags;
			Assert ("Flags/NoFlags=MemberAccess", !attr.MemberAccess);
			Assert ("Flags/NoFlags=ReflectionEmit", !attr.ReflectionEmit);
			Assert ("Flags/NoFlags=TypeInformation", !attr.TypeInformation);
		}

		[Test]
		public void NoFlags () 
		{
			ReflectionPermissionAttribute attr = new ReflectionPermissionAttribute (SecurityAction.Assert);
			AssertEquals ("NoFlags.Flags", ReflectionPermissionFlag.NoFlags, attr.Flags);
			Assert ("NoFlags.Unrestricted", !attr.Unrestricted);
			Assert ("NoFlags=MemberAccess", !attr.MemberAccess);
			Assert ("NoFlags=ReflectionEmit", !attr.ReflectionEmit);
			Assert ("NoFlags=TypeInformation", !attr.TypeInformation);
			ReflectionPermission p = (ReflectionPermission) attr.CreatePermission ();
			AssertEquals ("NoFlags=ReflectionPermission", ReflectionPermissionFlag.NoFlags, p.Flags);
		}

		[Test]
		public void MemberAccess () 
		{
			ReflectionPermissionAttribute attr = new ReflectionPermissionAttribute (SecurityAction.Assert);
			attr.MemberAccess = true;
			AssertEquals ("MemberAccess.Flags", ReflectionPermissionFlag.MemberAccess, attr.Flags);
			Assert ("MemberAccess.Unrestricted", !attr.Unrestricted);
			Assert ("MemberAccess=MemberAccess", attr.MemberAccess);
			Assert ("MemberAccess=ReflectionEmit", !attr.ReflectionEmit);
			Assert ("MemberAccess=TypeInformation", !attr.TypeInformation);
			ReflectionPermission p = (ReflectionPermission) attr.CreatePermission ();
			AssertEquals ("MemberAccess=ReflectionPermission", ReflectionPermissionFlag.MemberAccess, p.Flags);
		}

		[Test]
		public void ReflectionEmit () 
		{
			ReflectionPermissionAttribute attr = new ReflectionPermissionAttribute (SecurityAction.Assert);
			attr.ReflectionEmit = true;
			AssertEquals ("ReflectionEmit.Flags", ReflectionPermissionFlag.ReflectionEmit, attr.Flags);
			Assert ("ReflectionEmit.Unrestricted", !attr.Unrestricted);
			Assert ("ReflectionEmit=MemberAccess", !attr.MemberAccess);
			Assert ("ReflectionEmit=ReflectionEmit", attr.ReflectionEmit);
			Assert ("ReflectionEmit=TypeInformation", !attr.TypeInformation);
			ReflectionPermission p = (ReflectionPermission) attr.CreatePermission ();
			AssertEquals ("ReflectionEmit=ReflectionPermission", ReflectionPermissionFlag.ReflectionEmit, p.Flags);
		}

		[Test]
		public void TypeInformation () 
		{
			ReflectionPermissionAttribute attr = new ReflectionPermissionAttribute (SecurityAction.Assert);
			attr.TypeInformation = true;
			AssertEquals ("TypeInformation.Flags", ReflectionPermissionFlag.TypeInformation, attr.Flags);
			Assert ("TypeInformation.Unrestricted", !attr.Unrestricted);
			Assert ("TypeInformation=MemberAccess", !attr.MemberAccess);
			Assert ("TypeInformation=ReflectionEmit", !attr.ReflectionEmit);
			Assert ("TypeInformation=TypeInformation", attr.TypeInformation);
			ReflectionPermission p = (ReflectionPermission) attr.CreatePermission ();
			AssertEquals ("TypeInformation=ReflectionPermission", ReflectionPermissionFlag.TypeInformation, p.Flags);
		}

		[Test]
		public void AllFlags () 
		{
			ReflectionPermissionAttribute attr = new ReflectionPermissionAttribute (SecurityAction.Assert);
			attr.MemberAccess = true;
			attr.ReflectionEmit = true;
			attr.TypeInformation = true;
			AssertEquals ("AllFlags.Flags", ReflectionPermissionFlag.AllFlags, attr.Flags);
			// attribute isn't unrestricted but the created permission is !!!
			Assert ("AllFlags.Unrestricted", !attr.Unrestricted);
			Assert ("AllFlags=MemberAccess", attr.MemberAccess);
			Assert ("AllFlags=ReflectionEmit", attr.ReflectionEmit);
			Assert ("AllFlags=TypeInformation", attr.TypeInformation);
			ReflectionPermission p = (ReflectionPermission) attr.CreatePermission ();
			AssertEquals ("AllFlags=ReflectionPermission", ReflectionPermissionFlag.AllFlags, p.Flags);
			Assert ("AllFlags=Unrestricted", p.IsUnrestricted ());
		}

		[Test]
		public void Unrestricted () 
		{
			ReflectionPermissionAttribute a = new ReflectionPermissionAttribute (SecurityAction.Assert);
			a.Unrestricted = true;
			AssertEquals ("Unrestricted", ReflectionPermissionFlag.NoFlags, a.Flags);

			ReflectionPermission perm = (ReflectionPermission) a.CreatePermission ();
			AssertEquals ("CreatePermission.Flags", ReflectionPermissionFlag.AllFlags, perm.Flags);
		}
	}
}
