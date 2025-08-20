'use client';

import { useState, useEffect } from 'react';

export default function Home() {
  const [data, setData] = useState<unknown>('');

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch('/api/mc/list');
      console.log(response);
      // const result = await response.json();
      setData(response);
    };
    fetchData();
  }, []);
  return (
    <div>
    </div>
  );
}
