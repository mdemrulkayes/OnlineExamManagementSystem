﻿using System.Collections;

namespace Quizzer.Api.FunctionalTest.Abstraction;
internal class UserDataCollection : IEnumerable<object[]>
{

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    public IEnumerator<object[]> GetEnumerator()
    {
        yield return ["test1@gmail.com", "Aa123456#"];
        yield return ["test2@gmail.com", "Aa123456!"];
        yield return ["test3@gmail.com", "Aa123456%"];
    }
}

internal class UserEmailDataCollection : IEnumerable<object[]>
{

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    public IEnumerator<object[]> GetEnumerator()
    {
        yield return ["test1@gmail.com"];
        yield return ["test2@gmail.com"];
        yield return ["test3@gmail.com"];
    }
}
