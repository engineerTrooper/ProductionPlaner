namespace PP.Service;


public class MenuService
{
    public PP.Model.TemplateMeta templateMeta;

    public MenuService()
    {
        templateMeta = new PP.Model.TemplateMeta();
        GetTemplateMetas();
    }

    public async void GetTemplateMetas()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("version.json");
        using var reader = new StreamReader(stream);
        var contents = reader.ReadToEnd();
        this.templateMeta = JsonSerializer.Deserialize<PP.Model.TemplateMeta>(contents);
    }
}
