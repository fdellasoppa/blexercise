# blexercise

## Setup and Run
Code: https://github.com/fdellasoppa/blexercise.git

Database: Run "docker compose up -d" on BL.Students folder. This is for the MongoDb.

## Steps - Thought Process

1) Think about the Use Case, with some interesting business logic. Games or Students CRUD? Can have SSN column for some logic.

2) Think about data storage, decided on Mongo DB as ORMs are not permitted, wondering if I could use NHibernate though (not on the list and good experience with).

3) Start building Api

4) Separate Api between read-only and write apis. Not needed. Only main use case vs users Apis.

5) Considering KeyCloak or Auth0 for auth
Decided to start with KeyCloak and use Authorization Code flow. As I already had a KeyCloak instance running locally on Docker.

6) Remembered a project with IdentityServer and MongoDb as storage, this could be a faster solution.
Decided on this approach as KeyCloak does not support Mongo database for backup.

7) Searched for options with relational databases without ORMs, found Kysely. Will review in the future.

8) Clean architecture review, created layers for IdentityServer.

9) Finished first working version of the user create.

10) TDD before adding password validations to the model. Added email tests even not really valid (see comment on UserTests).

11) Test docker compose for database: Use "docker compose up -d"

12) Following:
https://www.yogihosting.com/aspnet-core-identity-mongodb/
https://www.yogihosting.com/identityserver-aspnet-core-identity-mongodb-database