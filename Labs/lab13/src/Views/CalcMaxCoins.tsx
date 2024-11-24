// CalcMaxCoinsComponent.tsx
import React, { useState } from 'react';
import { CalcMaxCoins } from '../Labs/CalcMaxCoins';
import { CalcPrefSum } from '../Labs/CalcPrefSum';

const CalcMaxCoinsComponent: React.FC = () => {
  const [coins, setCoins] = useState<string>('');
  const [N, setN] = useState<number>(0);
  const [K, setK] = useState<number>(0);
  const [result, setResult] = useState<number | null>(null);

  const handleCalculate = () => {
    const coinArray = coins.split(',').map(Number);
    const N = coinArray.length;
    const sum = CalcPrefSum.calculateRemainingCoins(coinArray, N);
    const maxCoins = CalcMaxCoins.calculateMaxCoins(coinArray, sum, N, K);
    setResult(maxCoins);
  };

  return (
    <div>
      <h1>Calculate Max Coins</h1>
      <div>
        <label>
          Enter Coins (comma separated):
          <input
            type="text"
            value={coins}
            onChange={(e) => setCoins(e.target.value)}
            placeholder="Наприклад: 3,2,5,6"
          />
        </label>
      </div>
      <div>
        <label>
          Enter K (number of stacks to take):
          <input
            type="number"
            value={K}
            onChange={(e) => setK(Number(e.target.value))}
          />
        </label>
      </div>
      <button onClick={handleCalculate}>Calculate</button>

      {result !== null && (
        <div>
          <h2>Maximum Coins for the First Player: {result}</h2>
        </div>
      )}
    </div>
  );
};

export default CalcMaxCoinsComponent;
