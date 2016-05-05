package me.test.scala

import Array._
import breeze.linalg.{DenseMatrix, Matrix}
import com.fasterxml.jackson.databind.ObjectMapper
import com.fasterxml.jackson.databind.node.ArrayNode
import org.apache.spark.rdd.RDD
import org.apache.spark.{SparkConf, SparkContext}

import scala.collection.mutable.ListBuffer
import collection.JavaConverters._

/**
  * Created by zll on 16-5-4.
  */
object Modulo {

  def main9(args: Array[String]): Unit = {
    val m = DenseMatrix(
      (2, 0, 0, 0),
      (0, 4, 0, 1),
      (0, 0, 6, 10),
      (0, 0, 0, 8)
    )
    println(m.forall(_ % 2 == 0))
    println("========")
    println(m)
  }

  def main(args: Array[String]): Unit = {

    //val json = """{"level":18,"modu":"2","map":["1010","0011","0101","1101","1110"],"pieces":["XX,.X",".X.,.X.,XXX","X.,XX,X.",".X..,XX..,.XXX,.XX.",".X.,XXX",".X..,XX..,XXXX,.X..",".X,.X,XX","X..,X..,XXX,XX.,X..","X.,X.,XX","X.,XX,.X"]}"""
    val json =
      """{"level":5,"modu":"2","map":["100","100","101"],"pieces":["X,X","XX,.X,.X","XXX","XX","XXX"]}"""
    val mapper = new ObjectMapper()
    val moduloLevel = mapper.readValue(json, classOf[ModuleLevel])
    println(moduloLevel)
    println("=============")

    val map: Matrix[Int] = mapToMatrix(moduloLevel.map)
    val pieces: Array[Matrix[Int]] = moduloLevel.pieces.map(pieceToMatrix(_))

    println("=========================map")
    println(map)
    println("=========================pieces.head")
    println(pieces.head)

    val conf = new SparkConf()
      .setAppName("btpka3")
      .setMaster("local[4]")

    val sc = new SparkContext(conf)
    val foundResult = sc.accumulator(0, "foundResult")
    //    val mapMatrix = sc.broadcast(map)

    println("=========================pieces.head.pos")
    println(calcPiecePos(map, pieces.head).map(pos => (pieces.head, pos)).getClass)
    calcPiecePos(map, pieces.head).map(pos => (pieces.head, pos)).foreach(println(_))
    val rdds: Array[RDD[(Matrix[Int], (Int, Int))]] = pieces.map(piece => sc.parallelize(calcPiecePos(map, piece).map(pos => (piece, pos))))
    println("----------------------------111" + rdds.getClass)
    var r: RDD[Array[(Matrix[Int], (Int, Int))]] = null
    var a = 0
    for (rdd <- rdds) {
      if (rdd == rdds.head) {
        r = rdd.map(Array(_))
      } else {
        r = r.cartesian(rdd.map(Array(_))).map(t2 => concat(t2._1, t2._2))
      }
      //val leftRdd = if (r == null) rdds.head else rdd
      //r = leftRdd.map(Array(_)).cartesian(rdd.map(Array(_))).map(t2 => concat(t2._1, t2._2))
    }
    println("----------------------------")
    r.collect().foreach(l => l.foreach(println(_)))
    //    println(rdd.collect())
    //rdd.repartition(4)


    //    rdd.map(piecePosArr => {
    //      piecePosArr.
    //    })
    //
    //    sc.parallelize(pieces)
    //      .map(piece => calcPiecePos(map, piece).map((piece, _)))
    //      .repartition(4)


    // piece => Array[(piece, pos)]
    //    val d = distData.flatMap { p =>
    //      Array(p + 100, p + 200)
    //    }
    //    println(d.collect().toList)
    // rdd1 =  piece1.map(_ -> Array[(_, pos)]))
    // rdd2 =  piece2.map(_ -> Array[(_, pos)]))
    // rddAll = rdd1.cartesian(rdd2).repartition(4)
  }

  def main0(args: Array[String]): Unit = {

    val map = mapToMatrix(Array("01010", "10100", "01101", "11101", "00111", "01011"))
    val piece = pieceToMatrix("XX.,.XX")

    println("---------------------map")
    println(map)
    println("---------------------piece")
    println(piece)
    println("---------------------pos")
    println(calcPiecePos(map, piece))
    println("---------------------add")
    addPieceToMap(map, piece, (1, 1))
    println(map)

    //println(mapToMatrix(Array("01010", "10100", "01101", "11101", "00111", "01011")))
    //    val arr = Array("XX.,.XX", "X,X,X,X", "X.XX,XXX.,.X..,.XX.", "XXX,.X.", "XXX..,X.XXX", "..X.,XXXX", ".X,XX,XX,X.", ".XXX,.XX.,..X.,XXX.,..X.", "...X,...X,XXXX", "..X,XXX", "..XX.,XXXXX,XX..X", "X..,X..,XXX,.X.")
    //    for (a <- arr) {
    //      println("------------------------------------")
    //      println(pieceToMatrix(a))
    //    }

    //
    //    val nums = 1 :: (2 :: (3 :: (4 :: Nil)))
    //    println(nums)
    //    println("111" :: "222" :: "333" :: Nil)
    //    var z: List[String] = List()
    //    //    z += "ccc"
    //    println(z)
    //    var z1 = new ListBuffer[String]()
    //    z1 += "ccc"
    //    z1 += "ddd"
    //    println(z1)
    //    var z2 = new ListBuffer[(Int,Int)]()
    //    z2 += ((1,1))
    //    z2 += ((2,2))
    //    println(z2)
    //
    //    val fruit1 = "apples" :: ("oranges" :: ("pears" :: Nil))
    //    val fruit2 = "mangoes" :: ("banana" :: Nil)
    //
    //    var ab = fruit1 ::: fruit2
    //    println(ab.::("ccc").::("ddd"))
  }

  //
  def mapToMatrix(strArr: Array[String]): Matrix[Int] = {
    // http://stackoverflow.com/questions/31064753/how-pass-scala-array-into-scala-vararg-method
    //var strArr = Array("01010", "10100", "01101", "11101", "00111", "01011")
    val a = strArr.map(str => str.map(x => x - 48)) // x => x.toString.toInt
    DenseMatrix(a: _*)
  }

  // "XX.,.XX"
  // ->
  // 110
  // 011
  def pieceToMatrix(str: String): Matrix[Int] = {
    val a = str.split(",").map(str => str.map(x => if ('X' == x) 1 else 0))
    DenseMatrix(a: _*)
  }


  def calcPiecePos(map: Matrix[Int], piece: Matrix[Int]): List[(Int, Int)] = {
    val arr = new ListBuffer[(Int, Int)]()
    for (i <- 0 to map.rows - piece.rows) {
      for (j <- 0 to map.cols - piece.cols) {
        arr += ((i, j))
      }
    }
    arr.toList
  }

  def addPieceToMap(map: Matrix[Int], piece: Matrix[Int], pos: (Int, Int)): Unit = {
    map(pos._1 until pos._1 + piece.rows, pos._2 until pos._2 + piece.cols) += piece
  }

  def isValidResult(filledMap: Matrix[Int], modu: Int): Boolean = {
    filledMap.forall(_ % modu == 0)
  }


  def main1(args: Array[String]): Unit = {
    val conf = new SparkConf()
      .setAppName("btpka3")
      .setMaster("local[2]")

    val sc = new SparkContext(conf)
    val data = Array(1, 2, 3, 4, 5)
    val distData = sc.parallelize(data)
    val d = distData.flatMap { p =>
      Array(p + 100, p + 200)
    }
    println(d.collect().toList)
  }


  def main2(args: Array[String]): Unit = {


    val s = """{"level":24,"modu":"2","map":["01010","10100","01101","11101","00111","01011"],"pieces":["XX.,.XX","X,X,X,X","X.XX,XXX.,.X..,.XX.","XXX,.X.","XXX..,X.XXX","..X.,XXXX",".X,XX,XX,X.",".XXX,.XX.,..X.,XXX.,..X.","...X,...X,XXXX","..X,XXX","..XX.,XXXXX,XX..X","X..,X..,XXX,.X."]}"""
    println("-------------------------99")
    println(s)
    println("-------------------------99")
    //JsonParser
    val mapper = new ObjectMapper()
    val node = mapper.readTree(s)
    println(node.get("modu"))
  }


  def main1(): Unit = {

  }

  /*
  1. 1
    */

}
