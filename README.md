# workout-tracker
This is a personal project to develop a fully functional PWA that works as a workout tracker to log all workouts and see your personal history.

## Status

This project is not deployed yet. It can be run locally:

1. Start PostgreSQL with Docker:

   ```bash
   cp .env.example .env
   docker compose up -d
   ```

2. Configure the local database connection:

   ```bash
   dotnet user-secrets set "ConnectionStrings:WorkoutTracker" "Host=localhost;Port=5432;Database=workout_tracker;Username=workout_tracker;Password=local_dev_only" --project backend/src/WorkoutTracker.Api/WorkoutTracker.Api.csproj --id WorkoutTracker-Api
   ```

   If you change the database password in `.env`, use that same password in the connection string.

3. Start the backend:

   ```bash
   dotnet run --project backend/src/WorkoutTracker.Api
   ```

4. In a second terminal, start the frontend:

   ```bash
   cd frontend/workout-tracker
   npm install
   npm start
   ```

5. Open `http://localhost:4200` in your browser.
