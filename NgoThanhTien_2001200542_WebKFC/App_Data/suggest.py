# -*- coding: utf-8 -*-
import sys
import csv
from prefixspan import PrefixSpan

def get_suggestions(cart_items):
    transaction_history = []
    try:
        with open("lichsu_giohang.csv", mode="r", encoding="utf-8") as f:
            print("Đã mở được file lichsu_giohang.csv")
            reader = csv.reader(f, delimiter=";")
            for row in reader:
                if len(row) < 2:
                    continue  
                items = list(map(int, row[1].split(',')))
                transaction_history.append(items)
        print(f"🧾 Tổng số giao dịch đọc được: {len(transaction_history)}")
    except Exception as e:
        print(f"Lỗi khi đọc file: {e}")
        return []  

    ps = PrefixSpan(transaction_history)
    frequent_patterns = ps.frequent(2)

    suggestions = {}
    print("Mẫu phổ biến tìm được:")
    for pattern, freq in frequent_patterns:
        if isinstance(pattern, int):
            pattern = [pattern]

        print(f"{pattern} (tần suất: {freq})")
        if any(item in pattern for item in cart_items):
            for item in pattern:
                if item not in cart_items:
                    suggestions[item] = suggestions.get(item, 0) + 1

    sorted_suggestions = sorted(suggestions.items(), key=lambda x: x[1], reverse=True)[:3]
    return [item[0] for item in sorted_suggestions]

if __name__ == "__main__":
    try:
        if len(sys.argv) < 2:
             raise ValueError("Bạn chưa truyền giỏ hàng vào script.")
        cart_items = list(map(int, sys.argv[1].split(',')))
        suggested_items = get_suggestions(cart_items)
        print(f"Gợi ý món: {suggested_items}")
        print(','.join(map(str, suggested_items)))
    except Exception as e:
        print(f"Lỗi khi chạy script chính: {e}")
