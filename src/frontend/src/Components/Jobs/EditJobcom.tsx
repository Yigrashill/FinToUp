import React from 'react'
import { useParams } from 'react-router-dom'

const EditJobcom = () => {

    const { id } = useParams<{id : number | any}>();

  return (
    <h1>Id {id}</h1>
  )
}

export default EditJobcom