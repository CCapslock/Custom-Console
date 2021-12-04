using UnityEngine;

namespace ClearParticls
{
    public class ClearParticleController : IObserver
    {
        private ClearParticleModel _clearParticleModel = Resources.Load<ClearParticleModel>("ClearParticle");

        public void ObserverUpdate(Vector3 points)
        {
            Object.Instantiate(_clearParticleModel, points, Quaternion.identity);
        }
    }
}

/* «јћ≈“ » Ќј «ј¬“–ј
- перенести все файлы св€занные с клеар партикл в отдельную папку с отдельной нэймспейс
-  леарѕартикл переиметовать  леарѕартиклћодел
- ƒобавить  леарѕартикл¬иев
- создать из префаба файл
- при завершении воспроизведени€ удалить
- мен€ет цвет частиц на такой же как у текстуры объекта
*/