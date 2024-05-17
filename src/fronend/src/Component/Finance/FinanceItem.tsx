import React, { useState } from 'react'
import { Finance } from '../../Types/Interface/Finance';
import { FinanceProps } from '../../Types/FinanceProps';
import { formatDate, getFinanceTypeName } from '../../Services/UtilityService';

const FinanceItem: React.FC<FinanceProps> = ({ finance }) => {
  
  return (
    <div id={`finance-${finance.id}`} className="bg-white rounded-xl shadow-md relative p-4">
      <p className="text-lg font-medium">{finance.title}</p>
      <p className="text-gray-600">Type: {getFinanceTypeName(finance.financeType)}</p>
        { finance.amount && 
          <p className="text-gray-800 font-semibold">
              Amount: { finance.amount} zł
          </p>}
        { finance.createrd && 
          <p> 
            Created: {formatDate(finance.createrd)}
          </p>
        }
        { finance.updated &&
        <p>
            Updated: {formatDate(finance.updated)}
            </p>
        }
    </div>
  )
}

export default FinanceItem