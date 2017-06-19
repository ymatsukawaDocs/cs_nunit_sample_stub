using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAppForUnitTest.Model;

namespace NUnit.RoomTest
{
    [TestFixture]
    public class RoomTest
    {
        private ILight light;

        // [Test], [TestCase] が実行される前に必ず実行される前処理メソッド
        // [SetUp] のアノテーションさえあれば 命名は BeforeTest() でなくてよい
        [SetUp]
        public void BeforeTest()
        {
            this.light = Substitute.For<ILight>();
            // private interface の light 変数へ スタブオブジェクトを参照させる
            // (なので、テストケースが実行されるたびに this.light では
            //  都度新たなスタブ(偽物)オブジェクトが参照していることになる)
        }

        // 単純なテストケース
        // 例として置いておく
        [Test]
        public void HelloTestWorld()
        {
            // 等価テストは AreEqual を使う
            Assert.AreEqual(1, 1); // 1 == 1
            Assert.AreEqual("foo", "foo");
        }

        // パラメーターテストは
        // [TestCase(..., ..., ...)] 1 列毎に実行される
        // 検証パターンを増やす場合は、3 列、4 列と列数を増やす
        //
        // ex.
        // [TestCase(A, B, C)]
        // [TestCase(D, E, F)]
        // [TestCase(G, H, I)]
        // public void SomeTest(param1, param2, param3)
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void RoomBrightnessTest(Boolean isLightBright, Boolean roomBrightOrNot)
        {
            // 1 回目は isLightBright に true が渡ってくる > すなわち 電灯を明るくした(スタブした) ので部屋は明るいはず(期待結果)
            // 2 回目は isLightBright に false が渡ってくる > すなわち 電灯を暗くした(スタブした) ので部屋が暗いはず(期待結果)
            this.light.Power.Returns(isLightBright);
            IRoom room = new Room(this.light);
            Assert.AreEqual(roomBrightOrNot, room.IsBrightRoom()); // パラメーターの true/false(期待結果) と room オブジェクトの true/false(実際結果) を比較する 
        }

        // [Test], [TestCase] が実行された後に必ず実行される後処理メソッド
        // [TearDown] のアノテーションさえあれば 命名は AfterTest() でなくてよい
        [TearDown]
        public void AfterTest()
        {
            this.light = null; // GC してくれるほどでもないが、null をアサインして後始末
        }

    }
}
