using System;

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name { get { return name; } }

    public bool LivesInNgr()
    {
        return address.IsInNgr();
    }

    public string GetAddressString()
    {
        return address.GetFullAddress();
    }
}
