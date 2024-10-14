using Sas.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Linq;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>().HasData(
            new Device {Id = 100, DeviceName="Curo 2 staff Fob",BatteryStatus=GetDescription(BatteryStatus.Status1), LocationDescriptor="Device Descriptor 1",
                Status="Live",DeviceID=Guid.Parse("164332cc-30ae-4d4d-8297-9c6d056ebdad"),CreatedAt=DateTime.UtcNow, TenantId=100},
            new Device {Id = 101, DeviceName="Curo 2 Nurse Fob", BatteryStatus=GetDescription(BatteryStatus.Status2), LocationDescriptor="Device Descriptor 2",
                Status="Live",DeviceID=Guid.Parse("348477a4-9933-42c1-9cc0-4deca317c62c"),CreatedAt=DateTime.UtcNow, TenantId=100}
        );

        modelBuilder.Entity<Tenant>().HasData(
            new Tenant {Id=100, CreatedAt = DateTime.UtcNow, Subscription="Standard", TenantID=Guid.NewGuid(),
                   TenantName="CloudSphere"},
            new Tenant {Id=101, CreatedAt = DateTime.UtcNow, Subscription="Standard", TenantID=Guid.NewGuid(),
                   TenantName="Datastream"},
            new Tenant {Id=102, CreatedAt = DateTime.UtcNow, Subscription="Premium", TenantID=Guid.NewGuid(),
                   TenantName="Bluewave"},
            new Tenant {Id=103, CreatedAt = DateTime.UtcNow, Subscription="Premium", TenantID=Guid.NewGuid(),
                   TenantName="AscendTech"}
        );
    }
    public static string GetDescription(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
    {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
    }
}

    public static class EnumExtensionMethodsAndGenerics
    {
        // }
        public static string GetDescription(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }
        // {
    }