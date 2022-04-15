# Bank Of Gringotts

This app simulates transactions made in gringotts bank at a very basic level.

It contains these:

- [ ] ExceptionHandling
- [ ] Loging
- [ ] Validation
- [ ] UnitOfWork
- [ ] GenericRepository Pattern
- [ ] Audit
- [ ] AutoMapper
- [ ] Authorization
- [ ] PostgreSql
- [ ] Heroku

- [ ] Validation
 All requests are filtered through Fluent validaton and cannot enter the system if they are not valid.

- [ ] Loging
All requests are logged to the console with serilog. Console is selected as sink, elk etc. can be updated.

- [ ] UnitOfWork
All crud operations were carried out by accepting the unit of work pattern and data consistency was ensured.
In simple terms, the work is done with the GenericRepository pattern.

- [ ] ExceptionHandling
In case of any error in the system, the exception handling middleware comes into play and logical responses are returned to the user.

- [ ] Audit
Changetracker is used. In this way, any row or column changes are logged as old and new versions.

- [ ] AutoMapper
Automapper is used for object swaps.

- [ ] PostgreSql
PostgreSql was used as RDBMS.

- [ ] Authorization
Added JWT based auth for Authorization. Requests can be sent to authorized services with bearer jwt. Otherwise it will return 401.