# Histogram

## Story

A histogram is an approximate, graphical representation of the distribution of numerical
or categorical data. Simply, it represents data using bars of different heights.
In a histogram, each bar group numbers into ranges. Taller bars show that more data falls
in that range. A histogram displays the shape and spread of continuous sample data.
To construct it, the first step is to get the range of values and then counting it occurrence
in your data.

For example, let's take below text and make histogram:

Harry Potter and the Sorcerer's Stone
Mr. and Mrs. Dursley, of number four, Privet Drive,
were proud to say that they were perfectly normal, thank you very much.

```
1  - 3 | *********
4  - 6 | ****************
7  - 9 | ***
```

See the above, there are 9 words in the range 1-3 letters count,
16 words in range 4-6, and 3 in the range 7  - 9. The punctuation signs are not included.

We need to ensure, that program which is already implemented will collect all data into histogram
correctly. You know, nobody like charts which shows incorrect data. So, let’s implement
unit tests. You should make your tests shine and ensure that they pay off more than they cost.
In this project, your job is to cover your code with tests, and make an assertion for all
the statements in the bullet points.

## What are you going to learn?

You'll have to:

- writing unit tests,
- developing boundary conditions,
- handling exceptions and covering them with tests,
- improving code to more efficient based on tests result.

## Tasks

1. There are separated files for testing purposes isolated from production code.
    - There are test files containing edge cases in `data` directory.
    - `SetUp` and `TearDown` annotations are used properly.

2. In `TextReader` class we have a ReadToEnd() method which returns `string` from the read file. Cover that method with tests, by implementing the `TextReaderTests` class.
    - When we provide the wrong file name, then we expect `FileNotFoundException` to be thrown.
    - Provide test cases for `Read()` method. The following cases should be covered: - existing but empty files - one line text in text file - multiple line in text file

3. `Range` class is covered with tests, by implementing the `RangeTests` class.
    - Provide test cases for constructor. The following cases should be covered:
- `from < 0`
- `to < from`
    - Provide test cases for `IsInRange()`. The following cases should be covered: - word's length in range - word's length equals to range `from` - word's length equals to range `to` - word's length is out of range
    - Provide test case for a `ToString()` method

4. `Histogram` class is covered with tests, by implementing the `HistogramTests` class.
    - Provide test cases for `GenerateRanges()`. The following cases should be covered: - positive integers added as parameters - negative integer as `step` parameter - negative integer as `amount` parameter
    - Provide test cases for `Generate()`. The method returns with counts of words with length in given ranges as a `Dictionary`. The following cases should be covered: - all words in `text` is in one of the given `ranges` - `text` with words out of given ranges - empty `text` - null as `text` - null as `ranges` - generate histogram multiple times
    - Provide test cases for `GetHistogram()` method. The following case should be covered: - Calling before generate histogram - Calling after generate histogram - Calling after multiple calls of `GenerateHistogram()`
    - String representation of histogram should present specific ranges
and their values displayed with proper asterisk repetition.
The following cases should be covered:
- Histogram before generate
- Histogram after generate

5. Min-max normalization, is the simplest method and consists in rescaling the range of features to
scale the range in [0, 1] or [−1, 1]. For the purpose of better diagram readability, we want to
scale words length ranges from 0 to 100. Please implement such a method in Histogram class, so
the max value on histogram could be less or equal than 100.
    - Get max value from histogram
    - Get min value from histogram
    - New value is calculated by given formula
`V' = (V - min) * 100 / (max - min)`.
Here is an example:
Assuming that for ranges max value is 115, and min 7, based on this if we
have 25 words in the range of 4-6 characters, we should get value 16 after
normalizing this range (fraction part in value result is not considered,
so we take an integer value)

6. Update the `HistogramTest` class to cover methods written in the previous step.
    - The `GetMin()` and `GetMax()` methods should return values accordingly.
    - String representation of histogram should present specific ranges
and their values from 0 to 100, represented by asterisk repetition

7. Try to optimize code and find a way to improve tests efficiency.
    - There is no unnecessary code repetition in test methods
    - Tests execution time is as short as possible
    - Test coverage of `Histogram`, `TextReader` and `Range` classes are 100%

## General requirements

- Every test methods' name follows the same naming convention.
In case of failing test, based on its name it is straightforward
which method, in which scenario has broken and what would be the expected behavior.
- The different assertion methods are used as intended. e.g. in case of examining a boolean value not `Assert.AreEqual(true, value)` is used but `Assert.True(value)` and so forth..

## Hints



## Background materials

- <i class="far fa-exclamation"></i> [Introduction to NUnit](https://www.c-sharpcorner.com/article/introduction-to-nunit-testing-framework/)
- <i class="far fa-exclamation"></i> [NUnit test naming conventions ](https://docs.nunit.org/2.5/sequential.html)
- <i class="far fa-exclamation"></i> [NUnit - Testing tests in particular order](https://docs.nunit.org/2.5/sequential.html)
- <i class="far fa-exclamation"></i> [NUnit Cheatsheet](https://www.automatetheplanet.com/nunit-cheat-sheet/)
- <i class="far fa-exclamation"></i> [Positive test or negative test](https://www.guru99.com/positive-and-negative-testing.html)

