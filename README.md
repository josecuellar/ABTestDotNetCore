<html>
<body>
<h2>Very simple language translation and HTML Cleaner for MVC</h2>
The library <b>get text of your HTML</b> for <b>translate</b> to all languages configured <b>and clean</b> unnecesary formats on the fly.

<hr>

<u>Configuration:</u> <br>

```
    <add key="TranslateEnabled" value="true"/> -> Enable text translation on the fly
    <add key="ClearCommentsAndUnnecesaryFormat" value="true"/> -> Clear and compress HTML
    <add key="SavePendingTranslations" value="true"/> --> Save pending text translations
    <add key="DefaultLanguageOfKeys" value="es-ES"/> --> Your default current culture
```

Implement your custom providers and parsers for translations dictionary.<br>
JSON is by Default. Create all JSON file by language:<br>

<pre>
-- ca-ES.json
-- en-GB.json
</pre>

<u>Example of content. Keys are the default text in default language culture configured:</u><br>

<pre>
{
  "Inicio": "Inici",
  "Bienvenido": "Benvingut",
  "Proyecto demo": "Projecte demo"
}
</pre>

Specify the language to translate in action controller:

```
	//System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ca-ES");
    System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-GB");
```

All pending translations not founded, save automatically in the same location to json files with the next format:

<pre>
-- ca-ES.Pending.json
</pre>

<u>Example of content:</u>

<pre>
{
  "Ejemplo 1": "write translation and move element to ca-ES.json",
  "Ejemplo 1 texto.": "write translation and move element to ca-ES.json",
}
</pre>

Only need replace in Views\web.config the next line:<br>

```
    <!--<pages pageBaseType="System.Web.Mvc.WebViewPage">-->
    <pages pageBaseType="LanguageParser.PageBaseType">
```

<br><br>

Feel free for fork and contribute!<br>
Thanks!

</body>
</html>



