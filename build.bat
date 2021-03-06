@echo off

ECHO DELETE OLD PACKAGES
del solrexpress.*.nupkg

ECHO RESTORE PACKAGES
dotnet restore

ECHO RUN TESTS
dotnet test ./test/SolrExpress.UnitTests/SolrExpress.UnitTests.csproj --verbosity minimal --framework "netcoreapp2.0" --configuration release
dotnet test ./test/SolrExpress.Solr4.UnitTests/SolrExpress.Solr4.UnitTests.csproj --verbosity minimal --framework "netcoreapp2.0" --configuration release
dotnet test ./test/SolrExpress.Solr5.UnitTests/SolrExpress.Solr5.UnitTests.csproj --verbosity minimal --framework "netcoreapp2.0" --configuration release

ECHO BUILD PACKAGES
dotnet pack src/SolrExpress/SolrExpress.csproj --configuration release --output ..\..
dotnet pack src/SolrExpress.Solr4/SolrExpress.Solr4.csproj --configuration release --output ..\..
dotnet pack src/SolrExpress.Solr5/SolrExpress.Solr5.csproj --configuration release --output ..\..
dotnet pack src/SolrExpress.DI.Autofac/SolrExpress.DI.Autofac.csproj --configuration release --output ..\..
dotnet pack src/SolrExpress.DI.CoreClr/SolrExpress.DI.CoreClr.csproj --configuration release --output ..\..
dotnet pack src/SolrExpress.DI.Ninject/SolrExpress.DI.Ninject.csproj --configuration release --output ..\..
dotnet pack src/SolrExpress.DI.SimpleInjector/SolrExpress.DI.SimpleInjector.csproj --configuration release --output ..\..

pause


