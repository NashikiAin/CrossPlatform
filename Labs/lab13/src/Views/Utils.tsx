import React, { useState } from "react";
import { Utils } from "../Labs/Utils";

const PermuteComponent: React.FC = () => {
  const [array, setArray] = useState<string>("1,2,3");
  const [k, setK] = useState<number>(1);
  const [result, setResult] = useState<number | null>(null);

  const handleCalculate = () => {
    const arr = array.split(",").map((num) => parseInt(num.trim(), 10));
    const count = { value: 0 };

    Utils.permute(arr, 0, k, count);
    setResult(count.value);
  };

  return (
    <div style={{ padding: "20px", fontFamily: "Arial" }}>
      <h1>Permute Validator</h1>
      <div style={{ marginBottom: "10px" }}>
        <label>Enter array (comma-separated): </label>
        <input
          type="text"
          value={array}
          onChange={(e) => setArray(e.target.value)}
          style={{ marginLeft: "10px" }}
        />
      </div>
      <div style={{ marginBottom: "10px" }}>
        <label>Enter K value: </label>
        <input
          type="number"
          value={k}
          onChange={(e) => setK(Number(e.target.value))}
          style={{ marginLeft: "10px" }}
        />
      </div>
      <button onClick={handleCalculate} style={{ padding: "5px 10px" }}>
        Calculate
      </button>
      <div style={{ marginTop: "20px" }}>
        {result !== null && <h2>Valid Permutations: {result}</h2>}
      </div>
    </div>
  );
};

export default PermuteComponent;
