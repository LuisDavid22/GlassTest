# GlassTest

## Just so you know...

I created a "IDocumentService" interface which defines the signature of the "SearchDocuments" method. There are two implementation of the "IDocumentService" and the differences are as follows:


**DocumentService Implementation:**
This implementation is the one i'd use in a real world escenario given that it uses the SQL Server Full-Text Search capabilities, that is ideal when performing searches by word and phrases on large data storages. The downsides of this approach is that the Full-Text Search capabilities needs to be installed in the SQL server engine and this might not always be the case and that's why I created an alternate implementation.

**DocumentServiceAlternative Implementation:**
This implementation is less performant given that it uses "Like" statements to perform the search. This implementation could be fine in the escenarios of small data storages.

To choose between implementations just change the service to be injected to IDocumentService in the "Program.cs" file:
