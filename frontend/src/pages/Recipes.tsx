
import React, { useEffect, useState } from 'react'
import axios from 'axios'

export default function Recipes(){
  const [recipes, setRecipes] = useState([])
  useEffect(()=>{ axios.get('/api/recipes').then(r=>setRecipes(r.data)).catch(()=>setRecipes([])) }, [])
  return (<div><h3>Recipes (React)</h3><ul>{recipes.map((r:any)=><li key={r.id}>{r.name}</li>)}</ul></div>)
}
