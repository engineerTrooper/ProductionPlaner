namespace PP.Service;


public class AdditionService
{
    List<Addition> additionList;

    public async Task<List<Addition>> GetAdditions()
    {
        if (additionList?.Count > 0)
            return additionList;

        using var stream = await FileSystem.OpenAppPackageFileAsync("additions.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        additionList = JsonSerializer.Deserialize<List<Addition>>(contents);

        return additionList;
    }
}
