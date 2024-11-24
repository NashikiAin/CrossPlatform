import React, { useState } from "react";
import { FindShortPath } from "../Labs/FindShortPath";

const FindShortPathComponent: React.FC = () => {
  const [maze, setMaze] = useState<string>(
    "2 0 0 1 1\n0 1 0 0 1\n1 1 0 0 1\n0 0 0 0 1\n3 1 0 0 1"
  );
  const [n, setN] = useState<number>(5); 
  const [m, setM] = useState<number>(5); 
  const [k, setK] = useState<number>(1); 
  const [startX, setStartX] = useState<number>(0);
  const [startY, setStartY] = useState<number>(0);
  const [endX, setEndX] = useState<number>(4);
  const [endY, setEndY] = useState<number>(0);
  const [result, setResult] = useState<number | null>(null);

  const handleCalculate = () => {
    // Convert maze string into a 2D array
    const mazeArray = maze
      .split("\n")
      .map((row) => row.split(" ").map((cell) => parseInt(cell.trim(), 10)));

    const distance = FindShortPath.find(
      mazeArray,
      n,
      m,
      k,
      startX,
      startY,
      endX,
      endY
    );
    setResult(distance);
  };

  return (
    <div style={{ padding: "20px", fontFamily: "Arial" }}>
      <h1>Find Shortest Path in Maze</h1>
      <div style={{ marginBottom: "10px" }}>
        <label>Enter maze (space-separated rows): </label>
        <textarea
          value={maze}
          onChange={(e) => setMaze(e.target.value)}
          style={{ marginLeft: "10px", width: "300px", height: "100px" }}
        />
      </div>
      <div style={{ marginBottom: "10px" }}>
        <label>Maximum right turns (K): </label>
        <input
          type="number"
          value={k}
          onChange={(e) => setK(Number(e.target.value))}
          style={{ marginLeft: "10px" }}
        />
      </div>
      <div style={{ marginBottom: "10px" }}>
        <label>Start X: </label>
        <input
          type="number"
          value={startX}
          onChange={(e) => setStartX(Number(e.target.value))}
          style={{ marginLeft: "10px" }}
        />
        <label>Start Y: </label>
        <input
          type="number"
          value={startY}
          onChange={(e) => setStartY(Number(e.target.value))}
          style={{ marginLeft: "10px" }}
        />
      </div>
      <div style={{ marginBottom: "10px" }}>
        <label>End X: </label>
        <input
          type="number"
          value={endX}
          onChange={(e) => setEndX(Number(e.target.value))}
          style={{ marginLeft: "10px" }}
        />
        <label>End Y: </label>
        <input
          type="number"
          value={endY}
          onChange={(e) => setEndY(Number(e.target.value))}
          style={{ marginLeft: "10px" }}
        />
      </div>
      <button onClick={handleCalculate} style={{ padding: "5px 10px" }}>
        Find Path
      </button>
      <div style={{ marginTop: "20px" }}>
        {result !== null && (
          <h2>
            Shortest Path Distance: {result === -1 ? "No path found" : result}
          </h2>
        )}
      </div>
    </div>
  );
};

export default FindShortPathComponent;
