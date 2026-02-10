using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panda.Minigames
{
    public static class Utils
    {
        public static void Shuffle<T>(IList<T> list)
        {
            for (var i = 0; i < list.Count - 2; i++)
            {
                var j = Random.Range(i, list.Count);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        public static List<T> PickRandom<T>(IList<T> list, int n)
        {
            var selected = new List<T>(list);
            Shuffle(selected);
            selected.RemoveRange(n, list.Count - n);
            return selected;
        }

        public static IEnumerator RotateTo(Transform transform, Quaternion end, float duration)
        {
            var start = transform.rotation;
            float timeElapsed = 0;

            while (timeElapsed < duration)
            {
                transform.rotation = Quaternion.Lerp(start, end, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            transform.rotation = end;
        }
    }
}