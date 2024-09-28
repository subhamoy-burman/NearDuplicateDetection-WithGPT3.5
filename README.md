# Near Duplicate Detection

This project is a simple console application that uses OpenAI's GPT-3.5 model to determine the similarity between two questions. The application prompts the user to input two questions and then labels them as "similar" or "not similar" based on the response from the OpenAI API.

## Features

- Prompts the user to enter two questions.
- Uses OpenAI's GPT-3.5 model to determine the similarity between the questions.
- Outputs the similarity label along with a rationale.

## Prerequisites

- .NET SDK installed on your machine.
- An OpenAI API key. You can get one by signing up at OpenAI.

## Installation

1. Clone the repository:
    ```sh
    git clone <your-repository-url>
    cd <your-repository-directory>
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

## Usage

1. Open the project in your preferred IDE or editor (e.g., Visual Studio, VS Code).

2. Replace `YOUR_OPEN_AI_KEY` in `Program.cs` with your actual OpenAI API key.

3. Run the application:
    ```sh
    dotnet run
    ```

4. Follow the prompts to enter the two questions you want to compare.

## Example

```sh
Enter the first question:
What is the capital of France?

Enter the second question:
Which city is the capital of France?

The questions are: similar
