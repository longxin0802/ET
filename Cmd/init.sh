#!/bin/bash

# 配置根目录（请修改为实际路径）
rootDir="../Packages"

# 需要跳过的目录名称（空格分隔）
skipDirNames="com.etetet.init com.halodi.halodi-unity-package-registry-manager com.unity.ide.rider .gitignore manifest.json packages-lock.json"

# 安全检查
if [ ! -d "$rootDir" ]; then
    echo "错误：根目录不存在或不可访问"
    exit 1
fi

if [ -z "$skipDirNames" ]; then
    echo "警告：跳过目录列表为空，将删除所有子目录"
    read -p "确认继续操作？(y/n) " -n 1 -r
    echo
    [[ $REPLY =~ ^[Yy]$ ]] || exit 1
fi

# 执行删除操作（安全演示版）
echo "即将在以下目录执行操作：$rootDir"
echo "跳过目录：$skipDirNames"

find "$rootDir" -mindepth 1 -maxdepth 1 -type d -print | while read -r dir; do
    dirName=$(basename "$dir")
    if [[ ! " $skipDirNames " =~ " $dirName " ]]; then
        echo "删除目录 $dir"
        # 实际执行时请取消以下注释
        rm -rf "$dir"
    else
        echo "跳过目录 $dir"
    fi
done

echo "操作完成（安全模式演示）"
