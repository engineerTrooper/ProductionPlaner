namespace PP.Service;

public class DefaultService
{
    public PP.Model.Defaults defaults;

    public DefaultService()
    {
        defaults = new PP.Model.Defaults();
        GetDefaults();
    }

    public async void GetDefaults()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("default.json");
        using var reader = new StreamReader(stream);
        var contents = reader.ReadToEnd();
        this.defaults = JsonSerializer.Deserialize<PP.Model.Defaults>(contents);
    }
}
