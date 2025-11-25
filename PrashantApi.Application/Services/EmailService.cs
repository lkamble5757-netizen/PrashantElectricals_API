using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

namespace PrashantApi.Application.Services
{
    public class EmailService
    {
        public string Render(string templatePath, object model)
        {
            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Template not found", templatePath);

            string html = File.ReadAllText(templatePath);

            // Replace simple placeholders {{Model.Property}}
            html = ReplaceSimpleValues(html, model);

            // Replace repeating sections: {{#each Model.List}} ... {{/each}}
            html = ReplaceRepeatingSections(html, model);

            return html;
        }

        private string ReplaceSimpleValues(string template, object model)
        {
            return Regex.Replace(template, "{{Model\\.(.*?)}}", match =>
            {
                string propName = match.Groups[1].Value;
                var prop = model.GetType().GetProperty(propName);
                if (prop == null) return "";
                var val = prop.GetValue(model);
                return val?.ToString() ?? "";
            });
        }

        private string ReplaceRepeatingSections(string template, object model)
        {
            return Regex.Replace(template,
                "{{#each Model\\.(.*?)}}(.*?){{\\/each}}",
                match =>
                {
                    string listName = match.Groups[1].Value;
                    string inner = match.Groups[2].Value;

                    var prop = model.GetType().GetProperty(listName);
                    if (prop == null) return "";

                    var list = prop.GetValue(model) as IEnumerable;
                    if (list == null) return "";

                    string result = "";

                    foreach (var item in list)
                    {
                        string row = inner;

                        foreach (var subProp in item.GetType().GetProperties())
                        {
                            row = row.Replace("{{" + subProp.Name + "}}",
                                subProp.GetValue(item)?.ToString() ?? "");
                        }

                        result += row;
                    }

                    return result;
                },
                RegexOptions.Singleline
            );
        }
    }
}


